import React, { Component } from 'react';
import { Formik, Form, ErrorMessage } from 'formik';
import * as Yup from 'yup';
import './addchecksheet.css';

export class AddCheckSheet extends Component {
    static displayName = AddCheckSheet.name;

    constructor() {
        super();

        this.formValues = {
            name: '',
            timeZoneId: ''
        };

        this.formValidationSchema = Yup.object().shape({
            name: Yup.string().required("Name required"),
            timeZoneId: Yup.string().required("Time zone required")
        });
    }

    onSubmit = (formJson) => {
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

    handleChange(evt) {
        this.setState({ [evt.target.name]: evt.target.value });
    }

    render() {
        return (

            <>
                <div id="sub-header" className="d-flex flex-row align-items-center justify-content-between py-0 px-4 bg-white">
                    <div>
                        <h4 id="sub-header-title" className="m-0 p-0">Add Checksheet</h4>
                    </div>

                    <div className="d-flex flex-row align-items-center justify-content-between">
                        <button className="pr-4">Today</button>
                        <button className="btn btn-primary btn-sm">Viewing: 8 Jan 2020 <i className="ml-1 fas fa-angle-down"></i></button>
                    </div>
                </div>

                <Formik
                    initialValues={this.formValues}
                    validationSchema={this.formValidationSchema}
                    onSubmit={this.onSubmit}>
                    {props => (
                        <Form onSubmit={props.handleSubmit}>
                            <div className="form-group">
                                <label>Checksheet Name</label>
                                <ErrorMessage name="name" component="div" className="" />
                                <input name="name" type="text" className="form-control" onChange={props.handleChange} value={props.values.name} />
                            </div>

                            <div className="form-group">
                                <label>Checksheet Time Zone</label>
                                <ErrorMessage name="timeZoneId" component="div" className="" />
                                <select className="form-control" name="timeZoneId" onChange={props.handleChange} value={props.values.timeZoneId}>
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

             </>
        );
    }
}
