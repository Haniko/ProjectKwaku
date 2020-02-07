import React, { Component } from 'react';
import { Route } from 'react-router';
import { Counter } from './components/Counter';
import { HomePage } from './components/homepage/homepage';
import { Layout } from './components/layout/layout';
import { TasksPage } from './components/taskspage/taskspage';

export default class App extends Component {
    static displayName = App.name;

    render() {
        return (
            <Layout>
                <Route exact path='/' component={HomePage} />
                <Route path='/counter' component={Counter} />
                <Route path='/checksheet/:checkSheetTypeId' component={TasksPage} />
            </Layout>
        );
    }
}
