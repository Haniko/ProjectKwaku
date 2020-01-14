import React, { Component } from 'react';
import { Route } from 'react-router';
import { Counter } from './components/Counter';
import { Dashboard } from './components/dashboard/dashboard';
import { HomePage } from './components/homepage/homepage';
import { Layout } from './components/layout/layout';

export default class App extends Component {
    static displayName = App.name;

    render() {
        return (
            <Layout>
                <Route exact path='/' component={HomePage} />
                <Route path='/counter' component={Counter} />
                <Route path='/dashboard' component={Dashboard} />
            </Layout>
        );
    }
}
