import logo from "../assets/logo.png"
import barras from "../assets/barras.png"
import { Component } from "react"
import "./css/Header.css"
import { Link } from "react-router-dom";

export default function Header() {
    return (
        <header>
            <Link className="barras-link" to='/produtos'>
                <img class="logo" src={logo}></img>
            </Link>


            <div>
                <input class="pesquisa" type="search">

                </input>
            </div>
            {/* <a href="">
              <img class="lupa" src="lupa.png"></img>
              </a> */}
            <Link className="barras-link" to='/reservas'>
                <img class="barras" src={barras}></img>
            </Link>
        </header>
    );

}