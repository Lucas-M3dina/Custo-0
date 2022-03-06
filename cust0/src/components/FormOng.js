import React from "react"
import { useState, useEffect } from "react";
import api from "../services/api";
import { useHistory } from "react-router-dom";

import '../css/Reset.css'
import './css/Forms.css';

export default function FormOng() {
    const [email, setEmail] = useState('');
    const [senha, setSenha] = useState('');
    const [confirmaSenha, setConfirmaSenha] = useState('');
    const [isLoading, setIsLoading] = useState(false);

    return (
        <div className='container_form_cliente'>
            <form className='form' action="">
                <div className='row_names'>
                    <input className='small_input' type="text" placeholder="Nome Fantasia"/>
                    <select className="small_input" name="" id="">
                        
                    </select>
                </div>

                <div className='row_names'>
                    <input className='small_input' type="text" name="" id="" placeholder="CEP"/>
                    
                    <input
                    className='small_input' type="text" placeholder="Rua"/>
                </div>

                <input
                className='normal_input' type="text" name="senha" id="" placeholder='Senha'/>


                <input
                className='normal_input' type="password" name="confirmaSenha" id="" placeholder='Confirme a senha'/>

                <input
                className='normal_input' type="password" name="confirmaSenha" id="" placeholder='Confirme a senha'/>

                {isLoading ? 
                <button className='btn_singup not_allowed' type="submit" disabled>Carregando...</button>
                :<button className='btn_singup' type="submit">Cadastrar</button> }
            </form>
        </div>
    )
}