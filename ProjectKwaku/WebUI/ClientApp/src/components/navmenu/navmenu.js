import React, { Component } from 'react';
import './navmenu.css';

export class NavMenu extends Component {
    static displayName = NavMenu.name;

    constructor() {
        super();
        this.state = { checklistTypes: [], loading: true };
    }

    componentDidMount() {
        this.getChecklistTypes();
    }

    async getChecklistTypes() {
        const response = await fetch('api/checklisttype/all');
        const data = await response.json();
        this.setState({ checklistTypes: data, loading: false });
    }

    getUrl(checklistTypeId) {
        return "/checklist/" + checklistTypeId;
    }

    getMenuOptions(checklistTypes) {
        return (
            checklistTypes.map(checklistType =>
                <li className="sidebar-menu-item checklist-item" key={checklistType.checklistTypeId}>
                    <a className="sidebar-menu-link" href={this.getUrl(checklistType.checklistTypeId)}>
                        <span className="sidebar-menu-text">{checklistType.name}</span>
                    </a>
                </li>
            )
        );
    }

    render() {
        let menuOptions = this.state.loading
            ? <p><em>Loading...</em></p>
            : this.getMenuOptions(this.state.checklistTypes);

        return (
            <div id="sidebar" className="brand-purple-bg">
                <div id="sidebar-brand">
                    <div id="sidebar-brand-logo">
                        <a href="/">
                            <img src="images/cpu-logo-white.png" alt="Computershare" />
                        </a>
                    </div>

                    <div id="sidebar-tools">
                        <button id="sidebar-toggle">
                            <span>
                                <i className="fas fa-chevron-left white"></i>
                            </span>
                        </button>
                    </div>
                </div>

                <div id="menu-wrapper">
                    <div id="sidebar-menu">
                        <ul id="sidebar-menu-nav">
                            <li className="sidebar-menu-item active">
                                <a className="sidebar-menu-link" href="/">
                                    <span className="sidebar-menu-icon"></span>
                                    <span className="sidebar-menu-text">Dashboard</span>
                                </a>
                            </li>
                            <li className="sidebar-menu-item">
                                <a className="sidebar-menu-link" href="#">
                                    <span className="sidebar-menu-icon"></span>
                                    <span className="sidebar-menu-text">Settings</span>
                                </a>
                            </li>
                            <li className="sidebar-menu-section checklist-item">
                                <h4 className="sidebar-menu-section-text">Checklists</h4>
                            </li>
                            {menuOptions}
                        </ul>
                    </div>
                </div>
            </div>
        );
    }
}
