import React, { Component } from 'react';
import './dashboard.css';
import '../header/header.css';
import { PageHeader } from '../header/pageheader';

export class Dashboard extends Component {
    static displayName = Dashboard.name;

    constructor() {
        super();
        this.state = { checkSheetDtos: null, loading: true };
    }

    componentDidMount() {
        this.getDashboard();
    }

    async getDashboard() {
        const response = await fetch('/api/checksheets/summary');
        const data = await response.json();
        this.setState({ checkSheetDtos: data, loading: false });
    }

    render() {
        let contents = (this.state.loading) ? "" : Dashboard.renderDashboard(this.state.checkSheetDtos);

        return (
            <>
                <PageHeader page_title="Dashboard"></PageHeader>

                <div>
                    {contents}
                </div>
             </>
        );
    }

    static renderDashboard(checkSheetDtos) {
        return (
            <table className='table table-striped' aria-labelledby="tabelLabel">
                <thead>
                    <tr>
                        <th>Id</th>
                        <th>Checksheet Name</th>
                        <th>Completed</th>
                        <th>In Progress</th>
                        <th>Not Started</th>
                    </tr>
                </thead>
                <tbody>
                    {
                        checkSheetDtos.map(checkSheetDto =>
                            <tr key={checkSheetDto.checkSheetTypeId}>
                                <td>{checkSheetDto.checkSheetTypeId}</td>
                                <td>{checkSheetDto.checkSheetName}</td>
                                <td>{checkSheetDto.completedCount}</td>
                                <td>{checkSheetDto.inProgressCount}</td>
                                <td>{checkSheetDto.notStartedCount}</td>
                            </tr>
                        )
                    }
                </tbody>
            </table>
        );
    }
}
