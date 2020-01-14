import React, { Component } from 'react';
import './dashboard.css';

export class Dashboard extends Component {
    static displayName = Dashboard.name;

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

    render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : Dashboard.renderChecklistTypes(this.state.checklistTypes);

        return (
            <div>
                <h1 id="tabelLabel">Checklist Types</h1>
                <p>This component demonstrates fetching data from the server.</p>
                {contents}
            </div>
        );
    }

    static renderChecklistTypes(checklistTypes) {
        return (
            <table className='table table-striped' aria-labelledby="tabelLabel">
                <thead>
                    <tr>
                        <th>Id</th>
                        <th>Name</th>
                    </tr>
                </thead>
                <tbody>
                    {
                        checklistTypes.map(checklistType =>
                            <tr key={checklistType.checklistTypeId}>
                                <td>{checklistType.checklistTypeId}</td>
                                <td>{checklistType.name}</td>
                            </tr>
                        )
                    }
                </tbody>
            </table>
        );
    }
}
