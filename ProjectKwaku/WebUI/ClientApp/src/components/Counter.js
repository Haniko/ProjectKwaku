import React, { Component } from 'react';

export class Counter extends Component {
  static displayName = Counter.name;

  constructor(props) {
    super(props);
    this.state = { currentCount: 0 };
    this.incrementCounter = this.incrementCounter.bind(this);
  }

  incrementCounter() {
    this.setState({
      currentCount: this.state.currentCount + 1
    });
  }

  render() {
      return (

          <>

              <div id="sub-header" className="d-flex flex-row align-items-center justify-content-between py-0 px-4 bg-white">
                  <div>
                      <h4 id="sub-header-title" className="m-0 p-0">Reporting</h4>
                  </div>

                  <div className="d-flex flex-row align-items-center justify-content-between">
                      <button className="pr-4">Today</button>
                      <button className="btn btn-primary btn-sm">Viewing: 8 Jan 2020 <i className="ml-1 fas fa-angle-down"></i></button>
                  </div>
              </div>

              <div>
                <h1>Settings</h1>

                <p>This is a simple example of a React component.</p>

                <p aria-live="polite">Current count: <strong>{this.state.currentCount}</strong></p>

                <button className="btn btn-primary" onClick={this.incrementCounter}>Increment</button>
               </div>
        </>
    );
  }
}
