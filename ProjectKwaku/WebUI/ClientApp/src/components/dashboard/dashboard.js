import React, { Component } from 'react';
import './dashboard.css';
import '../header/header.css';

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
                <div id="sub-header" className="d-flex flex-row align-items-center justify-content-between py-0 px-4 bg-white">
                    <div>
                        <h4 id="sub-header-title" className="m-0 p-0">Dashboard</h4>
                    </div>

                    <div className="d-flex flex-row align-items-center justify-content-between">
                        <button className="pr-4">Today</button>
                        <button className="btn btn-primary btn-sm">Viewing: 8 Jan 2020 <i className="ml-1 fas fa-angle-down"></i></button>
                    </div>
                </div>

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
