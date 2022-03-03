import { React, useState, useEffect } from 'react';
import axios from 'axios';
import nullProduct from "../assets/null.png"
import carrinho from "../assets/icoCarrinho.png"
import "../css/Produto.css"

export default function App() {

    const [produto, setProduto] = useState({});
    const [qntade, setQntade] = useState(1);

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
            .catch();
    }

    function postarReserva(event) {
        event.preventDefault()
        axios.post('', qntade, produto.id)
    }

    function onChange(event) {
        setQntade(event.target.value)
    }

    function telaProduto() {
        return (
            <section onSubmit={postarReserva} className='produto-section'>

                <form className='reservar-produto'>
                    {
                        produto.imagem != null ?
                            /// formato bd
                            // <img src={`data:image;base64,${p.imagem}`} alt="Imagem produto" /> :

                            /// formato mock
                            <img src={produto.imagem} alt="Imagem produto" /> :

                            <img src={nullProduct} alt="Imagem produto" />
                    }
                    <input type="number" value={qntade} onChange={onChange} min={1} />

                    <button typeof='submit'>
                        <img src={carrinho} alt="Adicionar" />
                        Adicionar
                    </button>
                </form>

                <div className='info-produto'>
                    <span className="produto-titulo">{produto.descricao}</span>
                    <hr />
                    <span className="produto-preco">{real.format(produto.preco)} un.</span>
                    <hr />
                    <span className="produto-descricao-t">Descrição:</span>
                    <p className="produto-descricao">{produto.description}</p>
                </div>

            </section>
        )
    }

    useEffect(buscarProduto, []);

    return (
        <div>
            {
                produto.id != null ?
                    telaProduto() :
                    <p>Não funciona!</p>
            }
        </div>
    )

}