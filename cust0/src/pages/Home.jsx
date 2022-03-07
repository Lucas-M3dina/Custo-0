import "../css/Home.css"
import Card from "../components/Card"
import { React, Component, useState, useEffect } from 'react';
import { Link } from "react-router-dom";

import api from "../services/api";
import logo from "../assets/logo.png"
import barras from "../assets/barras.png"
import "../components/css/Header.css"

import axios from "axios";

export default function App() {

    const [listaProdutos, setlistaProdutos] = useState([]);
    const [campoBusca, setCampoBusca] = useState('');

    function salvarProdutos() {
        // axios('https://621bca48768a4e10209ca218.mockapi.io/Produto')
        api.get('/produtos')
            .then(resposta => {
                if (resposta.status === 200) {
                    console.log(resposta.data)
                    setlistaProdutos(resposta.data)
                };
            })
            .catch(erro => console.log(erro));
    }

    function listarProdutos() {
        var r = new RegExp(campoBusca.toLowerCase(), "g")
            
        return(
            listaProdutos.map(p =>
                r.test(p.titulo.toLowerCase()) ?
                    <Card data={p} /> : null
            )
        )
    }

    function onChange(event) {
        setCampoBusca(event.target.value)
    }

    useEffect(salvarProdutos, []);

    return (
        <div>
            <header>
                <img class="logo" src={logo}></img>


                <div>
                    <input class="pesquisa" type="text" value={campoBusca} onChange={onChange} >

                    </input>
                </div>
                {/* <a href="">
              <img class="lupa" src="lupa.png"></img>
              </a> */}
                <Link class="barras-link" to='/reservas'>
                    <img class="barras" src={barras}></img>
                </Link>
            </header>
            <div className="container-login">
                <h1 className="titulo-login">Produtos</h1>
                <section className="section-login">
                    {
                        listarProdutos()
                    }
                </section>
            </div>
        </div>
    )
}