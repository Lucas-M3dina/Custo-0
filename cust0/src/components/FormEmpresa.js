import React from "react"
import { useState, useEffect } from "react";
import api from "../services/api";
import { useHistory } from "react-router-dom";

import '../css/Reset.css'
import './css/Forms.css';

export default function FormEmpresax() {
    const [cnpj, setCnpj] = useState('');
    const [email, setEmail] = useState('');
    const [senha, setSenha] = useState('');
    const [nomeFantasia, setNomeFantasia] = useState('');
    const [idEstado, setidEstado] = useState(0);
    const [cep, setCep] = useState('');
    const [rua, setRua] = useState('');
    const [confirmaSenha, setConfirmaSenha] = useState('');
    const [estados, setEstados] = useState([]);
    const [isLoading, setIsLoading] = useState(false);

    const history = useHistory()

    const buscarEstados = () => {
        api.get('/Estados')
        .then(resp => {
            if (resp.status === 200) {
                setEstados(resp.data)
                console.log('estados')
            }
        })
    }

    const cadastrarEmp =async (event) => {
        event.preventDefault();

        if(idEstado === 0) return

        setIsLoading(true)

        const dataEmp = {
            nomeFantasia: nomeFantasia,
            cnpj: cnpj,
            idEnderecoNavigation: {
                idEstado: idEstado,
                cep: cep,
                titulo: rua
            },
            idUsuarioNavigation: {
                email: email,
                senha: senha,
                IdTipoUsuario: 3
            }
        }

        await api.post('/Empresas',dataEmp)
        .then(response => {
            if (response.status == 201) {
                console.log('cadastrado')
                history.push('/')
                setIsLoading(false)
            }
        }).catch(erro => {
            console.log(erro)

            setIsLoading(false)
        })
    }

    useEffect(buscarEstados, [])

    return (
        <div className='container_form_cliente'>
            <form className='form' action="" onSubmit={cadastrarEmp}>
                <div className='row_names'>
                    <input 
                    onChange={campo => setNomeFantasia(campo.target.value)}
                    className='small_input' type="text" placeholder="Nome Fantasia" required/>
                    <select onChange={campo => setidEstado(campo.target.value)} className="small_input" name="select_estados" required>
                        <option value="0">Selecione um estado</option>
                        {estados.map(estado => {
                            return (
                                <option value={estado.idEstado}>{estado.nomeEstado}</option>
                            )
                        })}
                    </select>
                </div>

                <div className='row_names'>
                    <input 
                    onChange={campo => setCep(campo.target.value)} value={cep}
                    className='small_input' type="text" name="" id="" placeholder="CEP" required/>
                    
                    <input
                    onChange={campo => setRua(campo.target.value)} value={rua}
                    className='small_input' type="text" placeholder="Rua" required/>
                </div>

                <input
                onChange={campo => setEmail(campo.target.value)} value={email}
                className='normal_input' type="email" name="senha" id="" placeholder='E-mail' required/>


                <input
                onChange={campo => setSenha(campo.target.value) } value={senha}
                className='normal_input' type="password" name="confirmaSenha" id="" placeholder='Senha' required/>

                <input
                onChange={campo => setConfirmaSenha(campo.target.value)}
                className='normal_input' type="password" name="confirmaSenha" id="" placeholder='Confirme a senha' required/>

                {isLoading ? 
                <button className='btn_singup not_allowed' type="submit" disabled>Carregando...</button>
                :<button className='btn_singup' type="submit">Cadastrar</button> }
            </form>
        </div>
    )
}