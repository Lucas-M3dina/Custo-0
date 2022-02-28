import "../css/Home.css"
import Card from "../components/Card"
import { React, Component, useState, useEffect } from 'react';
import axios from "axios";

export default function App() {

    var produto = {
        id: 0,
        idTipoProduto: 0,
        idInstituicao: 0,
        preco: 0,
        quantidade: 0,
        descricao: '',
        imagem: '',
        dataValidade: new Date(),
    }

    const [listaProdutos, setlistaProdutos] = useState(produto);
    const [campoBusca, setCampoBusca] = useState('');

    function salvarProdutos() {
        axios('https://621bca48768a4e10209ca218.mockapi.io/Produto')
            .then(resposta => {
                if (resposta.status === 200) {
                    // console.log(resposta.data)
                    setlistaProdutos(resposta.data)
                };
            })
            .catch(erro => console.log(erro));
    }

    function listarProdutos() {
        var r = new RegExp(campoBusca.toLowerCase(), "g")

        return (
            listaProdutos.map(p =>
                r.test(p.descricao.toLowerCase()) ?
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
            <div className="container-login">
                <h1 className="titulo-login">Alimentos</h1>
                <input type="text" value={campoBusca} onChange={onChange} />
                <section className="section-login">
                    {

                        listarProdutos()

                    }
                </section>
                <script>
                    {

                    }
                </script>
            </div>
        </div>
    )
}