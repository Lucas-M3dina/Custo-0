import "../css/Home.css"
import carrinho from "../assets/icoCarrinho.png"
import foto from "../assets/maguaryUva.png"
import nullProduct from "../assets/null.png"
import { Component } from "react"
import { Link, Router } from "react-router-dom"


export default class Card extends Component {
    render() {

        const p = this.props.data

        const real = new Intl.NumberFormat([], {
            style: 'currency',
            currency: 'BRL'
        })

        return (
            <article className="card-article">

                {
                    p.imagem != null ?
                        /// formato bd
                        // <img src={`data:image;base64,${p.imagem}`} alt="Imagem produto" /> :

                        /// formato mock
                        <img src={p.imagem} alt="Imagem produto" /> :

                        <img src={nullProduct} alt="Imagem produto" />
                }

                <p>{p.descricao}</p>
                <span>{real.format(p.preco)} un.</span>

                <Link to={"/produto/" + p.id}>
                    <button>
                        <img src={carrinho} alt="" />
                        Adicionar
                    </button>
                </Link>
            </article>
        )
    }
}