import React from "react"
import { useState, useEffect } from "react";

//Forms
import FormCliente from "../components/FormCliente";
import FormOng from '../components/FormOng'
import FormEmpresa from '../components/FormEmpresa'

//css
import '../css/Cadastro.css'
import '../css/Reset.css'

const limpaBorder = async () => {
    var btnCliente = document.getElementById('cliente_btn')
    var btnOng = document.getElementById('ong_btn')
    var btnEmpresa = document.getElementById('empresa_btn')

    btnCliente.style.border = 'unset'
    btnOng.style.border = 'unset'
    btnEmpresa.style.border = 'unset'

    btnCliente.style.background = ''
    console.log('limpeis')
}

const highlightBtn = async (idBtn) => {
    limpaBorder()
    var bntCliente = document.getElementById(idBtn)

    bntCliente.style.border = '2px solid black';
}


export default function Cadastro() {

    const [formSelected, setFormSelected] = useState(1);

    const widthMain = {
        width: '65%'
    }

    const normal = {
        width: '40%'
    }

    return (
        <div className="cadastro_container">
            <main className="cdst_main" style={formSelected > 1 ? widthMain : normal}>

                <div className="cdst_container">
                    <h1 className='cdst_h1'>Cadastro</h1>
                    <div className="cdst_btns_container">
                        <button onClick={() => {setFormSelected(1);highlightBtn('cliente_btn')}} id='cliente_btn' className="cdst_btn_form_change">cliente</button>
                        <button onClick={() => {setFormSelected(2);highlightBtn('ong_btn')}} id='ong_btn' className="cdst_btn_form_change">ong</button>
                        <button onClick={() => {setFormSelected(3);highlightBtn('empresa_btn')}} id='empresa_btn' className="cdst_btn_form_change">empresa</button>
                    </div>
                </div>

                {formSelected === 1 && <FormCliente />}
                {formSelected === 2 && <FormOng />}
                {formSelected === 3 && <FormEmpresa />}
            </main>
        </div>
    )
}