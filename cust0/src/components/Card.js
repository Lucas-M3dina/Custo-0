import "../css/Home.css"
import carrinho from "../assets/icoCarrinho.png"
import foto from "../assets/maguaryUva.png"
import { Component } from "react"


export default class Card extends Component {
    render() {
        var p = this.props.data
        var real = new Intl.NumberFormat([], { 
            style: 'currency', 
            currency: 'BRL' 
          })
        return (
            <article className="card-article">
                                          {/* formato bd */}
                {/* <img src={`data:image;base64,${p.imagem}`} alt="Imagem produto" />  */}

                       {/* formato mockApi */}
                <img src={p.imagem} alt="Imagem produto" />

                <p>{p.descricao}</p>
                <span>{real.format(p.preco)} un.</span>

                <button>
                    <img src={carrinho} alt="" />
                    Adicionar
                </button>
            </article>
        )
    }
}