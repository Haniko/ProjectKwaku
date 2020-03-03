import React, { Component } from 'react';
import { EditCheckSheetModal } from '../modals/editchecksheetmodal';

export class ManageCheckSheet extends Component {
    static displayName = ManageCheckSheet.name;

    constructor() {
        super();
        this.state = {
            checkSheetEditDto: null,
            checkSheetTypes: null,
            loading: true,
            editCheckSheetModalOpen: false
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
        this.setState({ checkSheetEditDto: data, loading: false, editCheckSheetModalOpen: true });
    }

    onCheckSheetTypeRowClick(checkSheetType) {
        this.getCheckSheetToEdit(checkSheetType.checkSheetTypeId);
    }

    closeEditCheckSheetModal = () => this.setState({ editCheckSheetModalOpen: false });

    onFormSubmit = (formJson) => {
        fetch('/api/checksheets/types', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify(formJson),
        })
            .then((response) => response.json())
            .then((data) => {
                console.log('Success:', data);
            })
            .catch((error) => {
                console.error('Error:', error);
            });
    }

    render() {
        let checkSheetTypesTable = (this.state.loading)
            ? ""
            : this.renderCheckSheetTypesTable(this.state.checkSheetTypes);

        return (
            <>
                <div id="sub-header" className="d-flex flex-row align-items-center justify-content-between py-0 px-4 border-bottom bg-white">
                    <div>
                        <h4 id="sub-header-title" className="m-0 p-0">Manage Checksheets</h4>
                    </div>
                </div>

                {checkSheetTypesTable}

                <EditCheckSheetModal
                    isModalOpen={this.state.editCheckSheetModalOpen}
                    modalData={this.state.checkSheetEditDto}
                    onClose={this.closeEditCheckSheetModal}
                    onFormSubmit={this.onSubmit}>
                </EditCheckSheetModal>
            </>
        );
    }

    renderCheckSheetTypesTable(checkSheetTypes) {
        return (
            <table className="table table-striped">
                <thead>
                    <tr>
                        <th scope="col">Name</th>
                        <th scope="col">Time Zone</th>
                    </tr>
                </thead>
                <tbody>
                    {
                        checkSheetTypes.map(checkSheetType =>
                            <tr key={checkSheetType.checkSheetTypeId} onClick={() => this.onCheckSheetTypeRowClick(checkSheetType)}>
                                <td>{checkSheetType.name}</td>
                                <td>{checkSheetType.timeZoneId}</td>
                            </tr>
                        )
                    }
                </tbody>
            </table>
        )
    }
}
