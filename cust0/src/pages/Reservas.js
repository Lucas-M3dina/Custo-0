import React from "react"
import { useState, useEffect } from "react";
import { useHistory, Link } from "react-router-dom";
import Header from "../components/Header"
import api from "../services/api";

import '../css/Reset.css'
import '../css/Reservas.css'
import ReservaCard from "../components/ReservaCard";

export default function Reservas() {
    const [idReserva, setIdReserva] = useState(0);
    const [reservas, setReservas] = useState([]);

    const buscarReservas = () => {
        api.get('https://6220a847afd560ea6998ddcb.mockapi.io/reserva')
        .then(resp => {
            if (resp.status === 200) {
                console.log(resp.data)
                setReservas(resp.data)
            }
        })
    }

    useEffect(() => {
        buscarReservas()
    }, [])

    return (
        <div>
            <Header></Header>

            <div className='grid'>
                <h1 className='rsv_title'>Suas reservas</h1>

                {reservas.map(reserva => {
                    return (
                        <ReservaCard img={reserva.imagem} preco={reserva.preco} qntd={reserva.quantidade} />
                    )
                })}
            </div>
        </div>
    )
}