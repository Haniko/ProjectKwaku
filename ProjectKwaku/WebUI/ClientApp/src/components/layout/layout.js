import React, { Component } from 'react';
import { Header } from '../header/header'
import { NavMenu } from '../navmenu/navmenu';
import "./layout.css"

export class Layout extends Component {
    onSidebarToggle() {
        var sidebar = document.getElementById("sidebar");
        var header = document.getElementById("header");
        var main_content = document.getElementById("main-content");

        sidebar.classList.toggle("sidebar-minimised");
        header.classList.toggle("header-minimised");
        main_content.classList.toggle("main-content-minimised");
    }

    render() {
        return (
            <>
                <NavMenu onSidebarToggle={this.onSidebarToggle}></NavMenu>
                <Header></Header>
                <div id="main-content">
                    {this.props.children}
                </div>
            </>
        );
    }
}
