import React, { Component } from 'react';
import { Container } from 'reactstrap';
import { NavMenu } from '../navmenu/navmenu';
import "./layout.css"

export class Layout extends Component {
    render() {
        return (
            <>
                <NavMenu></NavMenu>
                <Container id="content" className="page-content p-5">
                    {this.props.children}
                </Container>
            </>
        );
    }
}
