import { React, Component, useState, useEffect } from 'react';
import axios from 'axios';
import nullProduct from "../assets/null.png"

export default function App() {

    const [produto, setProduto] = useState({});

    const real = new Intl.NumberFormat([], {
        style: 'currency',
        currency: 'BRL'
    })

    function buscarProduto() {

        var url_id = window.location.pathname.split('/')[2]
        // console.log(url)        

        axios(`https://621bca48768a4e10209ca218.mockapi.io/Produto/${url_id}`)
            .then(resposta => {
                if (resposta.status === 200) {
                    // console.log(resposta.data)
                    setProduto(resposta.data)
                };
            })
            .catch(erro => console.log(erro));
    }


    useEffect(buscarProduto, []);


    return (
        <div>

            {
                produto.id != null ?

                    <section className='produto-section'>
                        <img src={produto.imagem} alt="Imagem produto" />

                        {/* {
                            produto.imagem != null ?
                                /// formato bd
                                // <img src={`data:image;base64,${p.imagem}`} alt="Imagem produto" /> :

                                /// formato mock
                                <img src={produto.imagem} alt="Imagem produto" /> :

                                <img src={nullProduct} alt="Imagem produto" />
                        } */}

                        <div className='info-produto'>
                            <span className="produto-titulo">{produto.descricao}</span>
                            <span className="produto-preco">{real.format(produto.preco)}</span>
                            <span className="produto-descricao-t">Descrição:</span>
                            <p className="produto-descricao">{produto.descricao}</p>
                        </div>

                    </section>

                    :

                    <p>Não funciona!</p>
            }
        </div>
    )

}