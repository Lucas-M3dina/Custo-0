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

    const hisotry = useHistory();

    function Logar(event) {
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
            if (response.status == 200){
                localStorage.setItem('usuario-login', response.data.token)

                setSenha('')

                setEmail('')

                setIsLoading(false)

                hisotry.push('/produtos')
            }
        }).catch(erro => {
            console.log(erro)
    
            setSenha('')
    
            setErroMessage("Email ou senha inválidos")
    
            setIsLoading(false)
          })
    }

    return (
        <div className='container'>
            <main>
                <div className="background_main">
                    <div className="container_form">
                        <span className="login_text">Login</span>
                        <form onSubmit={Logar} className="form_login">
                            <div>
                                <input 
                                    onChange={campo => setEmail(campo.target.value)} 
                                    value={email} 
                                    placeholder='E-mail' 
                                    type="text" 
                                    className="email_input" />


                                <input 
                                    onChange={campo => setSenha(campo.target.value)}
                                    value={senha}
                                    placeholder="Senha"
                                    type="text"
                                    className="password_input" />
                              <Router>
                                    <Link className='forgot_pass' to='/'>Esqueceu a senha?</Link>
                                </Router>
                            </div>
                            
                            <button 
                            type="submit"
                            className={isLoading ? 'btn_login not_allowed' : 'btn_login pointer'}
                            disabled={isLoading ? 'disabled' : ''}
                            >{isLoading ? 'Carregando...' : 'Entrar'}</button>


                        </form>
                        <span className='singup'>Não tem uma conta?
                            <Router>
                                <Link className='link_signup' to='/cadastro'><span className='link_signup' >Cadastre-se</span></Link>
                            </Router>
                        </span>
                    </div>
                </div>
            </main>
        </div>
    )
}