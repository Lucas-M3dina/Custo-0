import logo from "../assets/logo.png"
import barras from "../assets/barras.png"
import { Component } from "react"
import "./css/Header.css"

export default class Header extends Component() {
    render() {
        return (
            <header>
                <img class="logo" src={logo}></img>


                <div>
                    <input class="pesquisa" type="search">

                    </input>
                </div>
                {/* <a href="">
              <img class="lupa" src="lupa.png"></img>
              </a> */}

                <img class="barras" src={barras}></img>
            </header>
        );
    }
}