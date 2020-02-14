import React, { Component } from 'react';
import { Route, Switch } from 'react-router';
import { Counter } from './components/Counter';
import { HomePage } from './components/homepage/homepage';
import { Layout } from './components/layout/layout';
import { TasksPage } from './components/taskspage/taskspage';
import { AddChecksheet } from './components/addchecksheet/addchecksheet';

export default class App extends Component {
    static displayName = App.name;

    render() {
        return (
            <Layout>
                <Route exact path='/' component={HomePage} />
                <Route path='/counter' component={Counter} />
                <Switch>
                    <Route exact path='/checksheet/add' component={AddChecksheet} />
                    <Route path='/checksheet/:checkSheetTypeId' component={TasksPage} />
                </Switch>
            </Layout>
        );
    }
}
