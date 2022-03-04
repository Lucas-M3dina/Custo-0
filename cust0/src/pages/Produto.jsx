import { React, useState, useEffect } from 'react';
import axios from 'axios';
import nullProduct from "../assets/null.png"
import carrinho from "../assets/icoCarrinho.png"

import edit from "../assets/icon-edit.svg"
import delet from "../assets/icon-delete.svg"
import "../css/Produto.css"

export default function App() {

    const [produto, setProduto] = useState({});
    const [qntade, setQntade] = useState(1);

    const [showModal, setShowModal] = useState(false);
    const [tipo, setTipo] = useState(0);
    const [preco, setPreco] = useState(0);
    const [estoque, setEstoque] = useState(0);
    const [img, setImg] = useState('');
    const [descricao, setDescricao] = useState('');


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

    function productTools() {
        return (
            <div className='produto-functions'>
                <img id="edit" onClick={abrirForm} src={edit} alt="Editar" />
                <img src={delet} alt="Deletar" />
            </div>
        )
    }

    function editarModal() {
        if (showModal == true) {
            return(
                <div className="fundo-pp" onClick={fecharForm}>
                            <div className="fechar"></div>
                            <form action="" onClick={stopPropagation} >
                                <h2>Editar Produto</h2>


                                <div>
                                    <span>Tipo de produto</span>
                                    <select name="" value={tipo} onChange={ (c) => setTipo(c.target.value) } id="">
                                        <option value={1}>Limpeza e Higiene</option>
                                        <option value={2}>Alimentação</option>
                                        <option value={3}>Lazer</option>
                                        <option value={4}>Eletrônicos</option>
                                        <option value={5}>Eletrodomésticos</option>
                                        <option value={6}>Estética</option>
                                    </select>
                                </div>

                                <div>
                                    <span>Preço(R$)</span>
                                    <input type="number" onChange={ (c) => setPreco(c.target.value) } name="" value={preco} id="" />
                                </div>

                                <div>
                                    <span>Estoque</span>
                                    <input type="number" onChange={ (c) => setEstoque(c.target.value) } name="" value={estoque} id="" />
                                </div>

                                <div>
                                    <span>Imagem</span>
                                    <input type="file" name="" id="" />
                                </div>

                                <div>
                                    <span>Descrição</span>
                                    <input className="input-descricao-pp" onChange={ (c) => setDescricao(c.target.value) } type="text" value={descricao} name="" id="" />
                                </div>


                                <button type="submit">Enviar</button>
                            </form>
                        </div>
            )
        } return(null)
        
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
                    { productTools() }
                    <span className="produto-titulo">{produto.descricao}</span>
                    <hr />
                    <span className="produto-preco">{real.format(produto.preco)} un.</span>
                    <hr />
                    <span className="produto-descricao-t">Descrição:</span>
                    <p className="produto-descricao">{produto.description}</p>
                </div>
                
                { editarModal() }
            </section>
        )
    }

    var modal = document.getElementsByClassName("fundo-pp");
    var btn = document.getElementById("edit");

    function abrirForm() {
        setShowModal(true)
    }

    function fecharForm() {
        setShowModal(false)
        console.log(`tipo: ${tipo}, preço: ${preco}, descricao: ${descricao}, qntade: ${estoque}`)
    }

    function stopPropagation(event) {
        event.stopPropagation();
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