import React, { Component } from 'react';
import { PageHeader } from '../header/pageheader';

export class ViewCheckSheet extends Component {
    static displayName = ViewCheckSheet.name;

    constructor(props) {
        super(props);

        this.state = {
            checkSheetTypeId: props.match.params.checkSheetTypeId,
            checkSheetDto: {},
            loading: true
        };
    }

    componentDidMount() {
        this.getTasks(this.state.checkSheetTypeId);
    }

    componentDidUpdate(props) {
        this.getTasks(props.match.params.checkSheetTypeId);
    }

    async getTasks(checkSheetTypeId) {
        const response = await fetch('api/checksheets/' + checkSheetTypeId);
        const data = await response.json();
        this.setState({ checkSheetDto: data, loading: false });
    }

    render() {
        var content = (this.state.loading) ? "<h1>Loading...</h1>" : this.renderTable(this.state.checkSheetDto);

        return (

            <>
                <PageHeader page_title={this.state.checkSheetDto.checkSheetName + " " + this.state.checkSheetDto.displayDate}></PageHeader>

                <div className="d-flex flex-column p-3">
                    <div className="d-flex flex-column panel mb-3 bg-white rounded">
                        <div className="d-flex flex-row align-items-center justify-content-between border-bottom p-3 mb-3">
                            <h6 className="p-0 m-0">Tasks</h6>
                        </div>
                        <div className="p-3">
                                {content}
                        </div>
                    </div>
                </div>
            </>
        );
    }

    renderTable(checkSheetDto) {
        return (
            <table className="table">
                <thead className="thead-dark">
                    <tr>
                        <th scope="col">Time</th>
                        <th scope="col">Title</th>
                        <th scope="col">Description</th>
                        <th scope="col">Notes</th>
                        <th scope="col">Comments</th>
                        <th scope="col">Status</th>
                        <th scope="col">Assigned To</th>
                    </tr>
                </thead>

                <tbody>
                    {
                        checkSheetDto.tasks.map(taskDto =>
                            <tr key={taskDto.taskId}>
                                <td>TBC</td>
                                <td>{taskDto.taskTitle}</td>
                                <td>{taskDto.taskDescription}</td>
                                <td>{taskDto.taskNotes}</td>
                                <td>{taskDto.taskComment}</td>
                                <td>{taskDto.status}</td>
                                <td>{taskDto.assignedUserName}</td>
                            </tr>
                        )
                    }
                </tbody>
            </table>
        )
    }
}

