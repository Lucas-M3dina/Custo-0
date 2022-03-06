import React from "react"
import { useState, useEffect } from "react";
import api from "../services/api";
import { useHistory } from "react-router-dom";

import '../css/Reset.css'
import './css/Forms.css';


export default function FormCliente() {

    const [nome, setNome] = useState('');
    const [sobreNome, setsobreNome] = useState('');
    const [cpf, setCpf] = useState('');
    const [email, setEmail] = useState('');
    const [senha, setSenha] = useState('');
    const [confirmaSenha, setConfirmaSenha] = useState('');
    const [isLoading, setIsLoading] = useState(false);

    const history = useHistory()

    const ConfirtPass = () => {
        
    }

    const CadastrarCliente = async (event) => {
        event.preventDefault();

        setIsLoading(true)

        const dataCliente = {
            nome: `${nome} ${sobreNome}`,
            documento: cpf,
            idUsuarioNavigation: {
                email: email,
                senha: senha,
                IdTipoUsuario: 2
            }
        }

        await api.post('/Cliente',dataCliente)
        .then(response => {
            if (response.status == 201) {
                console.log('cadastrado')
                history.push('/')
                setIsLoading(false)
            }
        }).catch(erro => {
            console.log(erro);

            setNome('')
            setsobreNome('')
            setCpf('')
            setEmail('')
            setSenha('')
            setConfirmaSenha('')

            setIsLoading(false)

        })
    }
    
    return (
        <div className='container_form_cliente'>
            <form className='form' onSubmit={CadastrarCliente}>
                <div className='row_names'>
                    <input 
                    onChange={campo => setNome(campo.target.value)} value={nome} required
                    className='small_input' type="text" name="nome" id="" placeholder='Nome' />

                    <input 
                    onChange={campo => setsobreNome(campo.target.value)} value={sobreNome} required
                    className='small_input' type="text" name="sobrenome" id="" placeholder='Sobrenome'/>
                </div>
                <input 
                onChange={campo => setCpf(campo.target.value)} value={cpf} required
                className='normal_input' type="text" name="cpf" id="" placeholder='CPF'/>

                <input
                onChange={campo => setEmail(campo.target.value)} value={email} required
                className='normal_input' type="email" name="email" id="" placeholder='E-mail'/>

                <input
                onChange={campo => setSenha(campo.target.value)} value={senha} required
                className='normal_input' type="password" name="senha" id="" placeholder='Senha'/>

                <input
                onChange={campo => setConfirmaSenha(campo.target.value)} value={confirmaSenha} required
                className='normal_input' type="password" name="confirmaSenha" id="" placeholder='Confirme a senha'/>

                {isLoading ? 
                <button className='btn_singup not_allowed' type="submit" disabled>Carregando...</button>
                :<button className='btn_singup' type="submit">Cadastrar</button> }
            </form>
        </div>
    )
}