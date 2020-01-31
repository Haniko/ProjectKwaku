import React, { Component } from 'react';
import { Container } from 'reactstrap';
import { NavMenu } from '../navmenu/navmenu';
import { Header } from '../header/header'
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
                <NavMenu onSidebarToggle={this.onSidebarToggle.bind(this)}></NavMenu>
                <Header></Header>
                <Container id="main-content">
                    {this.props.children}
                </Container>
            </>
        );
    }
}
