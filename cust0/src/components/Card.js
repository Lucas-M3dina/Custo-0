import "../css/Home.css"
import carrinho from "../assets/icoCarrinho.png"
import foto from "../assets/maguaryUva.png"


export default function Card(produto) {
    return (
        <article className="card-article">
            <img src={foto} alt="Suco de uva Maguary" />
            <p>Néctar de Uva Manguary 200ml</p>
            <span>R$ 1,09 un.</span>

            <button>
                <img src={carrinho} alt=""/>
                <p>Adicionar</p>
            </button>
        </article>
    )
}