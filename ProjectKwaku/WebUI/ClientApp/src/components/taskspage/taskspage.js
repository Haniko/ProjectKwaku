import React, { Component } from 'react';

export class TasksPage extends Component {
    static displayName = TasksPage.name;

    constructor(props) {
        super(props);

        this.state = {
            checkSheetTypeId: props.match.params.checkSheetTypeId,
            tasks: [],
            loading: true
        };
    }

    componentDidMount() {
        this.getTasks(this.state.checkSheetTypeId);
    }

    componentWillReceiveProps(props) {
        this.getTasks(props.match.params.checkSheetTypeId);
    }

    async getTasks(checkSheetTypeId) {
        const response = await fetch('api/checksheet/' + checkSheetTypeId);
        const data = await response.json();
        this.setState({ tasks: data, loading: false });
    }

    render() {
        return (
            <div className="d-flex flex-column p-3">
                <div className="d-flex flex-row align-items-center justify-content-between mb-3 panel p-3 bg-white rounded">
                    <div className="d-flex flex-row align-items-center">
                        <span></span>
                    <h6 className="p-0 m-0 mx-2">8 Jan 2020</h6>
                    </div>
                    <div className="d-flex flex-row align-items-center">
                        <button className="btn btn-danger btn-sm">Sign Off Required <i className="ml-1 fas fa-angle-down"></i></button>
                    </div>
                </div>

                <div className="d-flex flex-column panel mb-3 bg-white rounded">
                    <div className="d-flex flex-row align-items-center justify-content-between border-bottom p-3 mb-3">
                        <h6 className="p-0 m-0">Tasks</h6>
                    </div>
                    <div className="p-3">
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
                                    this.state.tasks.map(taskDto =>
                                        <tr key={taskDto.taskId}>
                                            <td>{taskDto.displayTime}</td>
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
                    </div>
                </div>
            </div>
        );
    }
}

