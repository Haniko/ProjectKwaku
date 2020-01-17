import React, { Component } from 'react';
import { Dashboard } from '../dashboard/dashboard';

export class HomePage extends Component {
    static displayName = HomePage.name;

    render() {
        return (
            <>
                <Dashboard />
            </>
        );
    }
}
