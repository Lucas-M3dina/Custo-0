import "../css/Home.css"

export default function Card(produto) {
    return (
        <article  >
            <img src={produto} alt="Suco de uva Maguary" />
            <p>Néctar de Uva Manguary 200ml</p>
            <span>R$ 1,09 un.</span>

            <button>
                <img src={carrinho} alt="" />
                Adicionar
            </button>
        </article>
    )
}