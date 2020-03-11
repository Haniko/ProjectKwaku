import React, { Component } from 'react';
import { Formik, Form, ErrorMessage } from 'formik';
import * as Yup from 'yup';

export class EditCheckSheetTypeForm extends Component {
    static displayName = EditCheckSheetTypeForm.name;

    constructor(props) {
        super();

        this.state = {
            name: props.checkSheetType.name,
            timeZoneId: props.checkSheetType.timeZoneId,
            timeZonesDtos: []
        };

        this.formValidationSchema = Yup.object().shape({
            name: Yup.string().required("Name required"),
            timeZoneId: Yup.string().required("Time zone required")
        });
    }

    componentDidMount() {
        this.getTimeZones();
    }

    async getTimeZones() {
        const response = await fetch('/api/timezone');
        const data = await response.json();
        this.setState({ timeZonesDtos: data, loading: false });
    }

    handleInputChange = (event) => {
        this.setState({ [event.target.name]: event.target.value });
    }

    onFormSubmit = (formValues) => {
        fetch('/api/checksheets/types', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify(formValues),
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
        let timeZoneOptions = this.state.timeZonesDtos.map(t =>
            <option value={t.id} key={t.id}>{t.displayName}</option>
        )

        return (
            <Formik
                enableReinitialize
                initialValues={this.state}
                validationSchema={this.formValidationSchema}
                onSubmit={this.onFormSubmit}>
                {props => (
                    <Form>
                        <div className="form-group col-md-6">
                            <label>Checksheet Name</label>
                            <ErrorMessage name="name" component="div" className="" />
                            <input name="name" type="text" className="form-control" onChange={this.handleInputChange} value={props.values.name} />
                        </div>

                        <div className="form-group col-md-6">
                            <label>Checksheet Time Zone</label>
                            <ErrorMessage name="timeZoneId" component="div" className="" />
                            <select className="form-control" name="timeZoneId" onChange={this.handleInputChange} value={props.values.timeZoneId}>
                                {timeZoneOptions}
                            </select>
                        </div>

                        <div className="form-group col-md-6">
                            <button type="submit" className="btn btn-primary mr-2">Submit</button>
                        </div>
                    </Form>
                )}
            </Formik>
        )
    }
}