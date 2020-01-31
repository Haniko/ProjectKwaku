import React, { Component } from 'react';

export class TasksPage extends Component {
    static displayName = TasksPage.name;

    constructor(props) {
        super(props);

        this.state = {
            checklistTypeId: props.match.params.checklistTypeId,
            checklist: null,
            loading: true
        };
    }

    componentDidMount() {
        this.getChecklist(this.state.checklistTypeId);
    }

    componentWillReceiveProps(props) {
        this.getChecklist(props.match.params.checklistTypeId);
    }

    async getChecklist(checklistTypeId) {
        const response = await fetch('api/checklist/' + checklistTypeId);
        const data = await response.json();
        this.setState({ checklist: data, loading: false });
    }

    render() {
        return (
            <div className="d-flex flex-column p-3">
                <div className="d-flex flex-row align-items-center justify-content-between mb-3 panel p-3 bg-white rounded">
                    <div className="d-flex flex-row align-items-center">
                        <span>
                        </span>
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
                                    <th scope="col">Task</th>
                                    <th scope="col">User</th>
                                    <th scope="col">Comments</th>
                                    <th scope="col">Complete</th>
                                </tr>
                            </thead>
                            <tbody>
                                <tr>
                                    <th scope="row">12:00</th>
                                    <td>Bank File Download</td>
                                    <td>aitkenl</td>
                                    <td>4 files downloaded</td>
                                    <td>
                                        <button className="rounded rounded-sm bg-success text-white px-2 py-1">
                                            <i className="fa fa-check"></i>
                                        </button>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                </div>
            </div>
        );
    }
}
