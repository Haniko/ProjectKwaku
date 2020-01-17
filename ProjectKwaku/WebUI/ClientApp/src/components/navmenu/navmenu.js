import React, { Component } from 'react';
import './navmenu.css';

export class NavMenu extends Component {
    static displayName = NavMenu.name;

    render() {
        return (
			<div id="sidebar" className="brand-purple-bg">
				<div id="sidebar-brand">
					<div id="sidebar-brand-logo">
						<a href="/">
							<img className="logo" src="images/cpu-logo-white.png" alt="Computershare" />
						</a>
					</div>

					<div id="sidebar-tools">
						<button id="sidebar-toggle">
							<span>
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
                            <li className="sidebar-menu-item checklist-item">
                                <a className="sidebar-menu-link" href="checklist.html">
                                    <span className="sidebar-menu-text">North America</span>
                                </a>
                            </li>
                            <li className="sidebar-menu-item checklist-item">
                                <a className="sidebar-menu-link" href="#">
                                    <span className="sidebar-menu-text">EMEA</span>
                                </a>
                            </li>
                            <li className="sidebar-menu-item checklist-item">
                                <a className="sidebar-menu-link" href="#">
                                    <span className="sidebar-menu-text">Oceania</span>
                                </a>
                            </li>
                            <li className="sidebar-menu-item checklist-item">
                                <a className="sidebar-menu-link" href="#">
                                    <span className="sidebar-menu-text">Miscellaneous</span>
                                </a>
                            </li>
                            <li className="sidebar-menu-item checklist-item">
                                <a className="sidebar-menu-link" href="#">
                                    <span className="sidebar-menu-text">CLS</span>
                                </a>
                            </li>
                            <li className="sidebar-menu-item checklist-item">
                                <a className="sidebar-menu-link" href="#">
                                    <span className="sidebar-menu-text">CVS</span>
                                </a>
                            </li>
                        </ul>
                    </div>
                </div>
			</div>
        );
    }
}
