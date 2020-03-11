import React, { Component } from 'react';
import { EditCheckSheetTypeForm } from '../forms/editchecksheettypeform'

export class ManageCheckSheet extends Component {
    static displayName = ManageCheckSheet.name;

    constructor() {
        super();

        this.state = {
            checkSheetEditDto: null,
            checkSheetTypes: [],
            loading: true,
            selectedCheckSheetTypeId: 0
        };
    }

    componentDidMount() {
        this.getCheckSheetTypes();
    }

    async getCheckSheetTypes() {
        const response = await fetch('/api/checksheets/types');
        const data = await response.json();
        this.setState({ checkSheetTypes: data, loading: false });
    }

    async getCheckSheetToEdit(checkSheetTypeId) {
        const response = await fetch('/api/checksheets/edit/' + checkSheetTypeId);
        const data = await response.json();
        this.setState({ selectedCheckSheetTypeId: checkSheetTypeId, checkSheetEditDto: data, loading: false });
    }

    onDropDownChange = (event) => {
        this.getCheckSheetToEdit(event.target.value);
    }

    onTaskClick = (task) => {
        console.log("onTaskClick");
        console.log(task);
    }

    render() {
        let checkSheetTypeDropDown = this.getCheckSheetTypesDropDown();
        let tasksTable = this.getTasksTable();
        let checkSheetTypeForm = this.getCheckSheetTypeForm();

        return (
            <>
                <div id="sub-header" className="d-flex flex-row align-items-center justify-content-between py-0 px-4 border-bottom bg-white">
                    <h4 id="sub-header-title" className="m-0 p-0">Manage Checksheets</h4>
                </div>

                <div className="m-3">
                    {checkSheetTypeDropDown}
                    {checkSheetTypeForm}
                    {tasksTable}
                </div>
            </>
        )
    }

    getCheckSheetTypesDropDown() {
        if (this.state.checkSheetTypes == null) return null;

        let options = this.state.checkSheetTypes.map(c =>
            <option key={c.checkSheetTypeId} value={c.checkSheetTypeId}>{c.name}</option>
        );

        return (
            <>
                <div className="form-group">
                    <select className="form-control" value={this.state.selectedCheckSheetTypeId} onChange={this.onDropDownChange}>{options}</select>
                </div>
                <hr />
            </>
        )
    }

    getCheckSheetTypeForm() {
        if (this.state.checkSheetEditDto == null) return null;

        return (
            <>
                <div className="form-group">
                    <EditCheckSheetTypeForm
                        checkSheetType={this.state.checkSheetEditDto.checkSheetType}>
                    </EditCheckSheetTypeForm>
                </div>
                <hr />
            </>
        )
    }

    getTasksTable() {
        if (this.state.checkSheetEditDto == null) return null;

        let rows = this.state.checkSheetEditDto.activeTasks.map(t =>
            <tr key={t.taskId} onClick={() => this.onTaskClick(t)}>
                <td>{t.title}</td>
                <td>{t.description}</td>
            </tr>
        );

        return (
            <table className="table table-hover">
                <thead className="thead-dark">
                    <tr>
                        <th className="w-25" scope="col">Title</th>
                        <th scope="col">Description</th>
                    </tr>
                </thead>
                <tbody>{rows}</tbody>
            </table>
        )
    }
}
