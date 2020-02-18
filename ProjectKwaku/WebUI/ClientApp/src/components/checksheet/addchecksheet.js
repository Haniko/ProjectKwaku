import React, { Component } from 'react';
import './addchecksheet.css';

export class AddCheckSheet extends Component {
    static displayName = AddCheckSheet.name;

    constructor() {
        super();

        this.state = {
            checkSheetName: "",
            timezoneId: ""
        };
    }

    onSubmit() {
        event.preventDefault();
        console.log(this.state);
    }

    handleChange(evt) {
        this.setState({ [evt.target.name]: evt.target.value });
    }

    render() {
        return (
            <form onSubmit={this.onSubmit.bind(this)}>
                <div className="form-group">
                    <label>Checksheet Name</label>
                    <input type="text" className="form-control" name="checkSheetName" onChange={this.handleChange.bind(this)} />
                </div>
                <div className="form-group">
                    <label>Checksheet Time Zone</label>
                    <select className="form-control" name="timezoneId" onChange={this.handleChange.bind(this)}>
                        <option>(UTC-05:00) Eastern Time (US & Canada)</option>
                        <option>(UTC+00:00) Dublin, Edinburgh, Lisbon, London</option>
                        <option>(UTC+10:00) Canberra, Melbourne, Sydney</option>
                    </select>
                </div>
                <button type="submit" className="btn btn-primary">Submit</button>
            </form>
        );
    }
}
