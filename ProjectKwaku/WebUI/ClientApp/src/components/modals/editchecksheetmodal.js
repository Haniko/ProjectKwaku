import React, { Component } from 'react';
import Modal from 'react-bootstrap/Modal'
import Button from 'react-bootstrap/Button'
import { Formik, Form, ErrorMessage } from 'formik';
import * as Yup from 'yup';

export class EditCheckSheetModal extends Component {
    static displayName = EditCheckSheetModal.name;

    constructor(props) {
        super(props);
        this.state = { checkSheet: null, loading: true, modalOpen: false };

        this.formValidationSchema = Yup.object().shape({
            name: Yup.string().required("Name required"),
            timeZoneId: Yup.string().required("Time zone required")
        });
    }

    handleChange(evt) {
        this.setState({ [evt.target.name]: evt.target.value });
    }

    render() {
        let modalHeader = this.getModalHeader();
        let modalBody = this.getModalBody(this.props);
        let modalFooter = this.getModalFooter(this.props);

        return (
            <Modal
                show={this.props.isModalOpen}
                onHide={this.props.onClose}
                size="lg"
                aria-labelledby="contained-modal-title-vcenter"
                centered
            >
                {modalHeader}
                {modalBody}
                {modalFooter}
            </Modal>
        );
    }

    getModalHeader() {
        return (
            <Modal.Header closeButton>
                <Modal.Title>Edit Checksheet</Modal.Title>
            </Modal.Header>
        )
    }

    getModalBody(props) {
        console.log(props);
        let formValues = { name: "", timeZoneId: ""};

        if (props.modalData) {
            formValues = {
                name: props.modalData.checkSheetType.name,
                timeZoneId: props.modalData.checkSheetType.timeZoneId
            };
        }

        return (
            <Modal.Body>
                <Formik
                    initialValues={formValues}
                    validationSchema={this.formValidationSchema}
                    onSubmit={props.onFormSubmit}>
                    {props => (
                        <Form onSubmit={props.onSubmit}>
                            <div className="form-group">
                                <label>Checksheet Name</label>
                                <ErrorMessage name="name" component="div" className="" />
                                <input name="name" type="text" className="form-control" onChange={this.handleChange} value={props.values.name} />
                            </div>

                            <div className="form-group">
                                <label>Checksheet Time Zone</label>
                                <ErrorMessage name="timeZoneId" component="div" className="" />
                                <select className="form-control" name="timeZoneId" onChange={this.handleChange} value={props.values.timeZoneId}>
                                    <option>(UTC-05:00) Eastern Time (US & Canada)</option>
                                    <option>(UTC+00:00) Dublin, Edinburgh, Lisbon, London</option>
                                    <option>(UTC+10:00) Canberra, Melbourne, Sydney</option>
                                </select>
                            </div>

                            <div className="form-group">
                                <button type="submit" className="btn btn-primary mr-2">Submit</button>
                            </div>
                        </Form>
                    )}
                </Formik>
            </Modal.Body>
        )
    }

    getModalFooter(props) {
        return (
            <Modal.Footer>
                <Button onClick={props.onClose}>Close</Button>
            </Modal.Footer>
        )
    }
}
