import React, { Component } from 'react';
import './header.css';

export class Header extends Component {
    static displayName = Header.name;

    constructor() {
        super();
    }

    render() {
        return (
            <div id="header" className="fixed-top">
                <div id="main-header" className="d-flex flex-row align-items-center justify-content-between py-0 px-4 brand-purple-bg">
                    <h4 className="m-0 p-0 text-white main-header-title">CTS Operations Daily Check Sheets</h4>
                    <h4 className="m-0 p-0 text-white main-header-title">Liam Aitken</h4>
                </div>
            </div>
        );
    }
}
