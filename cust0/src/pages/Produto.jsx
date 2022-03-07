import { React, useState, useEffect } from 'react';
import { useHistory, Link, BrowserRouter as Router } from "react-router-dom";
import axios from 'axios';
import nullProduct from "../assets/null.png"
import carrinho from "../assets/icoCarrinho.png"
import edit from "../assets/icon-edit.svg"
import delet from "../assets/icon-delete.svg"
import "../css/Produto.css"
import api from '../services/api';
import Header from "../components/Header"
import { parseJwt } from '../services/auth';


export default function App() {

    const [produto, setProduto] = useState({});
    const [qntade, setQntade] = useState(1);

    const [showModal, setShowModal] = useState(false);
    const [titulo, setTitulo] = useState('');
    const [tipo, setTipo] = useState(0);
    const [preco, setPreco] = useState(0);
    const [estoque, setEstoque] = useState(0);
    const [img, setImg] = useState('');
    const [descricao, setDescricao] = useState('');

    const history = useHistory();
    const [erroMessage, setErroMessage] = useState('dsadadas');

    const real = new Intl.NumberFormat([], {
        style: 'currency',
        currency: 'BRL'
    })

    var empresa

    function buscarProduto() {
        var url_id = window.location.pathname.split('/')[2]
        // console.log(url)        

        api.get(`/produtos/${url_id}`)
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
        api.post('/reservas', {
            quantidade: qntade,
            idProduto: produto.id
        }, { headers: { 'Authorization': 'Bearer ' + localStorage.getItem('usuario-login') } })
            .then((resposta) => {
                if (resposta.status == 201) {
                    history.push('/reservas')
                }
            })
            .catch(erro => { console.log(erro) })
    }

    function postarDoacao(event) {
        event.preventDefault()
        api.post('/reservas/doacao', {
            quantidade: qntade,
            idProduto: produto.id
        }, { headers: { 'Authorization': 'Bearer ' + localStorage.getItem('usuario-login') } })
            .then((resposta) => {
                if (resposta.status == 201) {
                    history.push('/reservas')
                }
            })
            .catch(erro => { console.log(erro) })
    }

    function editarProduto(event) {
        event.preventDefault()

        var pAtualizado = produto

        pAtualizado.idTipoProduto = tipo
        pAtualizado.preco = preco
        pAtualizado.quantidade = estoque
        pAtualizado.titulo = titulo
        pAtualizado.descricao = descricao


        api.put(`/produtos/${produto.idProduto}`, pAtualizado, { headers: { 'Authorization': 'Bearer ' + localStorage.getItem('usuario-login') } })
            .then((resposta) => {
                if (resposta.status == 204) {
                    fecharForm()
                } else {
                    setErroMessage("Erro. Informações inválidas.")
                }

            })
            .catch(erro => {
                console.log(erro)
                setErroMessage("Erro. Tente novamente mais tarde.")
            })
    }

    function excluirProduto() {
        api.delete(produto.idProduto, { headers: { 'Authorization': 'Bearer ' + localStorage.getItem('usuario-login') } })
        history.push('/produtos')
    }

    function onChange(event) {
        setQntade(event.target.value)
    }

    function productTools() {
        if (empresa != null) {

            if (empresa.idEmpresa == produto.idEmpresa) {
                return (
                    <div className='produto-functions'>
                        <img id="edit" onClick={abrirForm} src={edit} alt="Editar" />
                        <img src={delet} onClick={excluirProduto} alt="Deletar" />
                    </div>
                )
            }
        }
        return null
    }

    function formEditar() {
        if (showModal == true) {
            return (
                <div className="fundo-pp" onClick={fecharForm}>
                    <div className="fechar"></div>
                    <form
                        onSubmit={editarProduto}
                        onClick={stopPropagation}
                    >
                        <h2>Editar Produto</h2>

                        <div>
                            <span>Titulo</span>
                            <input type="text" onChange={(c) => setTitulo(c.target.value)} value={titulo} />
                        </div>

                        <div>
                            <span>Tipo de produto</span>
                            <select value={tipo} onChange={(c) => setTipo(c.target.value)} >
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
                            <input type="number" onChange={(c) => setPreco(c.target.value)} value={preco} />
                        </div>

                        <div>
                            <span>Estoque</span>
                            <input type="number" onChange={(c) => setEstoque(c.target.value)} value={estoque} />
                        </div>

                        <div>
                            <span>Imagem</span>
                            <input type="file" />
                        </div>

                        <div>
                            <span>Descrição</span>
                            <textarea className="input-descricao-pp" onChange={(c) => setDescricao(c.target.value)} type="" value={descricao} />
                        </div>

                        <span className="lgn_erromsg">{erroMessage}</span>

                        <button type="submit">Enviar</button>
                    </form>
                </div>
            )
        } return (null)

    }

    function telaProduto() {
        return (
            <section className='produto-section'>


                <form className='reservar-produto' onSubmit={postarReserva}>
                    {
                        produto.imagemProduto != null ?
                            /// formato bd
                            // <img src={`data:image;base64,${p.imagem}`} alt="Imagem produto" /> :

                            /// formato mock
                            <img src={produto.imagemProduto} alt="Imagem produto" /> :

                            <img src={nullProduct} alt="Imagem produto" />
                    }
                    <input type="number" value={qntade} onChange={onChange} min={1} />

                    <button typeof='submit'>
                        <img src={carrinho} alt="Adicionar" />
                        Adicionar
                    </button>
                    {
                        parseJwt().role == 3 ?
                            <button onClick={postarDoacao} id='doa'>
                                Pedir doação
                            </button>

                            : null
                    }
                </form>

                <div className='info-produto'>
                    {productTools()}
                    <span className="produto-titulo">{produto.titulo}</span>
                    <hr />
                    <span className="produto-preco">{real.format(produto.preco)} un.</span>
                    <hr />
                    <span className="produto-descricao-t">Descrição:</span>
                    <p className="produto-descricao">{produto.descricao}</p>
                </div>

                {formEditar()}
            </section>
        )
    }

    var modal = document.getElementsByClassName("fundo-pp");
    var btn = document.getElementById("edit");

    function abrirForm() {
        console.log(produto)
        setTitulo(produto.titulo)
        setTipo(produto.idTipoProduto)
        setPreco(produto.preco)
        setEstoque(produto.quantidade)
        setImg(produto.imagemProduto)
        setDescricao(produto.descricao)
        setErroMessage('')
        setShowModal(true)
    }

    function fecharForm() {
        setShowModal(false)
    }

    function stopPropagation(event) {
        event.stopPropagation();
    }

    function findIdEmpresa() {
        if (parseJwt().role == '1') {
            api.get('/empresas/user/' + parseJwt().jti)
                .then(r => empresa = r.data)
        }
    }

    useEffect(
        buscarProduto,
        []
    );

    return (
        <div>
            <Header></Header>
            {
                produto.idProduto != null ?
                    telaProduto() :
                    <p>Não encontrado.</p>
            }
        </div>
    )

}