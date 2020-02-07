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

                <div id="sub-header" className="d-flex flex-row align-items-center justify-content-between py-0 px-4 bg-white">
                    <div>
                        <h4 id="sub-header-title" className="m-0 p-0">Dashboard</h4>
                    </div>

                    <div className="d-flex flex-row align-items-center justify-content-between">
                        <button className="pr-4">Today</button>
                        <button className="btn btn-primary btn-sm">Viewing: 8 Jan 2020 <i className="ml-1 fas fa-angle-down"></i></button>
                    </div>
                </div>
            </div>
        );
    }
}
