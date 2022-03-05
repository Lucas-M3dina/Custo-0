import { useEffect } from 'react'

import '../css/Reservas.css'
import '../css/Reset.css'


export default function ReservaCard(img, preco, qntd) {
    const printa = () => {
        console.log(img)
    }

    useEffect(() => {printa()})
    return (
        <div className="rsv_card">
            <div className='rsv_container_img'>
                <img className='rsv_img_card' src={img.img} alt="" />
                <span name='preco' className='rsv_preco'>R$ 2,29 un.</span>
            </div>
            <div className='rsv_container_qntd'>
                <span>5 un.</span>
            </div>
            <div>
                <button className='rsv_btn_shop'>Ir a loja</button>
                <img src="" alt="" />
            </div>
        </div>
    )
}