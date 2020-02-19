import React, { Component } from 'react';
import './header.css';

export class PageHeader extends Component {
    static displayName = PageHeader.name;

    constructor(props) {
        super(props);
    }

    render() {

        var page_title = this.props.page_title;

        return (
            <div id="sub-header" className="d-flex flex-row align-items-center justify-content-between py-0 px-4 bg-white">
                <div>
                    <h4 id="sub-header-title" className="m-0 p-0">{page_title}</h4>
                </div>
            </div>
        );
    }
}
