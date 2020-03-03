import React, { Component } from 'react';
import { Route, Switch } from 'react-router';
import { Reporting } from './components/Reporting';
import { HomePage } from './components/homepage/homepage';
import { Layout } from './components/layout/layout';
import { ViewCheckSheet } from './components/checksheet/viewchecksheet';
import { ManageCheckSheet } from './components/checksheet/managechecksheet';

export default class App extends Component {
    static displayName = App.name;

    render() {
        return (
            <Layout>
                <Route exact path='/' component={HomePage} />
                <Route path='/reporting' component={Reporting} />
                <Switch>
                    <Route exact path='/checksheet/manage' component={ManageCheckSheet} />
                    <Route exact path='/checksheet/:checkSheetTypeId' component={ViewCheckSheet} />
                </Switch>
            </Layout>
        );
    }
}
