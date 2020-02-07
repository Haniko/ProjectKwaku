import React, { Component } from 'react';
import './dashboard.css';

export class Dashboard extends Component {
    static displayName = Dashboard.name;

    constructor() {
        super();
        this.state = { checkSheetTypes: [], loading: true };
    }

    componentDidMount() {
        this.getCheckSheetTypes();
    }

    async getCheckSheetTypes() {
        const response = await fetch('api/checksheettype/all');
        const data = await response.json();
        this.setState({ checkSheetTypes: data, loading: false });
    }

    render() {
        let contents = (this.state.loading) ? "" : Dashboard.renderCheckSheetTypes(this.state.checkSheetTypes);

        return (
            <div>
                <h1 id="tabelLabel">Checklist Types</h1>
                <p>This component demonstrates fetching data from the server.</p>
                {contents}
            </div>
        );
    }

    static renderCheckSheetTypes(checkSheetTypes) {
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
                        checkSheetTypes.map(checkSheetType =>
                            <tr key={checkSheetType.checkSheetTypeId}>
                                <td>{checkSheetType.checkSheetTypeId}</td>
                                <td>{checkSheetType.name}</td>
                            </tr>
                        )
                    }
                </tbody>
            </table>
        );
    }
}
