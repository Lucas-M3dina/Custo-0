import { useEffect } from 'react'
import {parseJwt} from '../services/auth'

import '../css/Reservas.css'
import '../css/Reset.css'
import api from '../services/api'


export default function ReservaCard(reserva) {

    const printa = () => {
        console.log(reserva.reserva.idReserva)
    }

    const aceitarSolicitacao = () => {
        const data = {
            idReserva: reserva.reserva.idReserva,
            idSituacao: 3
        }

        api.put('/Reservas/' + reserva.reserva.idReserva, data)
    }

    useEffect(() => {printa()})
    return (
        <div className="rsv_card">
            <div className='rsv_container_img'>
                <img className='rsv_img_card' src={reserva.reserva.idProdutoNavigation.imagemProduto} alt="" />
                <span name='preco' className='rsv_preco'>R${reserva.reserva.preco}</span>
            </div>
            <div className='rsv_container_qntd'>
                <span>{reserva.reserva.quantidade} un.</span>
            </div>
            <div className='rsv_btn_container'>
                <button className='rsv_btn_shop'>{reserva.reserva.idSituacaoNavigation.tituloReserva}</button>

                {reserva.reserva.idSituacao === 1 && parseJwt().role == '1' ?
                 <div className='rsv_btn_intern'>
                     <button onClick={aceitarSolicitacao} className='rsv_btn_accept'>Aceitar</button>
                     <button className='rsv_btn_accept'>Recusar</button>
                 </div>
                  : <button className='none'>?</button>}
                {/* <button className='rsv_btn_accept'>Aceitar</button> */}
                {/* <img src="" alt="" /> */}
            </div>
        </div>
    )
}