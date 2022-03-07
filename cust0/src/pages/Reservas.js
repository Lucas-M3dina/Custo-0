import React from "react"
import { useState, useEffect } from "react";
import { useHistory, Link } from "react-router-dom";
import Header from "../components/Header"
import api from "../services/api";

import '../css/Reset.css'
import '../css/Reservas.css'
import ReservaCard from "../components/ReservaCard";
import {parseJwt} from '../services/auth'

export default function Reservas() {
    const [idReserva, setIdReserva] = useState(0);
    const [reservas, setReservas] = useState([]);

    const buscarTodasReservar = () => {
        api.get('/reservas')
        .then(resp => {
            if (resp.status === 200) {
                setReservas(resp.data)
            }
        }).catch(erro => {
            console.log(erro)
        })
    }

    const buscarReservasCliente = () => {
        api.get('/Reservas/cliente', {
            headers : {
                'Authorization' : 'Bearer ' + localStorage.getItem('usuario-login')
            }
        })
        .then(resp => {
            if (resp.status === 200) {
                setReservas(resp.data)
            }
        }).catch(erro => {
            console.log(erro)
        })
    }

    const buscarReservasEmpresa = () => {
        api.get('/Reservas/empresa', {
            headers: {
                'Authorization' : 'Bearer ' + localStorage.getItem('usuario-login')
            }
        })
        .then(resp => {
            if (resp.status === 200) {
                setReservas(resp.data)
            }
        }).catch(erro => {
            console.log(erro)
        })
    }

    useEffect(() => {
        switch (parseJwt().role) {
            // Empresa
            case '1':
                buscarReservasEmpresa()
                break;
            
            // Ong
            case '2':
                buscarReservasCliente()
                break;

            // Cliente
            case '3':
                buscarReservasCliente()
                break;
        
            default:
                break;
        }
    }, [])

    return (
        <div>
            <Header></Header>

            <div className='grid'>
                <h1 className='rsv_title'>Suas reservas</h1>

                {reservas.map(reserva => {
                    return (
                        <ReservaCard reserva={reserva} />
                    )
                })}
            </div>
        </div>
    )
}