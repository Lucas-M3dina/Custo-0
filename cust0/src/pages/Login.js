import React from "react"
import { useState, useEffect } from "react";
import { useHistory, Link, BrowserRouter as Router } from "react-router-dom";
import api from "../services/api";

import background from "../assets/loginBackGround.png"
import '../css/Login.css'
import '../css/Reset.css'

export default function Login() {
    const [email, setEmail] = useState('');
    const [senha, setSenha] = useState('');
    const [isLoading, setIsLoading] = useState(false);
    const [erroMessage, setErroMessage] = useState('');

    const history = useHistory();

    const Logar = (event) => {
        event.preventDefault();

        setErroMessage('');
        setIsLoading(true);

        console.log(isLoading)
        console.log('ola')

        api.post('/login', {
            email: email,
            senha: senha
        })
            .then(response => {
                if (response.status == 200) {
                    localStorage.setItem('usuario-login', response.data.token)

                    setSenha('')

                    setEmail('')

                    setIsLoading(false)

                    history.push('/produtos')
                }
            }).catch(erro => {
                console.log(erro)

                setSenha('')

                setErroMessage("Email ou senha inválidos")

                setIsLoading(false)
            })
    }

    return (
        <div className='lgn_container'>
            <main className="lgn_main">
                <div className="lgn_background_main">
                    <div className="lgn_container_form">
                        <span className="lgn_login_text">Login</span>
                        <form onSubmit={Logar} className="lgn_form_login">
                            <div>
                                <input
                                    required
                                    onChange={campo => setEmail(campo.target.value)}
                                    value={email}
                                    placeholder='E-mail'
                                    type="text"
                                    className="lgn_email_input lgn_input" />


                                <input
                                    required
                                    onChange={campo => setSenha(campo.target.value)}
                                    value={senha}
                                    placeholder="Senha"
                                    type="password"
                                    className="lgn_input lgn_password_input" />
                                <Link className='lgn_forgot_pass' to='/'>Esqueceu a senha?</Link>
                            </div>

                            <button
                                type="submit"
                                className={isLoading ? 'lgn_btn_login lgn_not_allowed' : 'lgn_btn_login lgn_pointer'}
                                disabled={isLoading ? 'disabled' : ''}
                            >{isLoading ? 'Carregando...' : 'Entrar'}</button>

                            <span className="lgn_erromsg">{erroMessage}</span>


                        </form>
                        <span className='lgn_singup'>Não tem uma conta?
                            <Link className='lgn_link_signup' to='/cadastro'><span className='link_signup' >Cadastre-se</span></Link>
                        </span>
                    </div>
                </div>
            </main>
        </div>
    )
}