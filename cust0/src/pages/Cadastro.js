import React from "react"
import { useState, useEffect } from "react";

import '../css/Cadastro.css'


export default function Cadastro() {

    return (
        <div className="cadastro_container">
            <main>
                <span>Cadastro</span>

                <button>cliente</button>
                <button>ong</button>
                <button>empresa</button>
            </main>
        </div>
    )
}