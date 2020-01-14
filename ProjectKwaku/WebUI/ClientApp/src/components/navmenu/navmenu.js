import React, { Component } from 'react';
import './navmenu.css';

export class NavMenu extends Component {
    static displayName = NavMenu.name;

    constructor(props) {
        super(props);

        this.toggleNavbar = this.toggleNavbar.bind(this);
        this.state = {
            collapsed: true
        };
    }

    toggleNavbar() {
        this.setState({
            collapsed: !this.state.collapsed
        });
    }

    render() {
        return (
            <div className="vertical-nav bg-white" id="sidebar">
                <p className="font-weight-bold px-3 small pb-4 mb-0">Checklists</p>

                <ul className="nav flex-column bg-white mb-0">
                    <li className="nav-item">
                        <a href="#" className="nav-link text-dark font-italic bg-light">
                            <i className="fa fa-th-large mr-3 text-primary fa-fw"></i>
                            <span>Home</span>
                        </a>
                    </li>
                    <li className="nav-item">
                        <a href="#" className="nav-link text-dark font-italic">
                            <i className="fa fa-address-card mr-3 text-primary fa-fw"></i>
                            <span>About</span>
                        </a>
                    </li>
                    <li className="nav-item">
                        <a href="#" className="nav-link text-dark font-italic">
                            <i className="fa fa-cubes mr-3 text-primary fa-fw"></i>
                            <span>Services</span>
                        </a>
                    </li>
                </ul>
            </div>
        );
    }
}
