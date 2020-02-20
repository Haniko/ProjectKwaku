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

              <div id="sub-header" className="d-flex flex-row align-items-center justify-content-between py-0 px-4 border-bottom bg-white">
                  <div>
                      <h4 id="sub-header-title" className="m-0 p-0">Reporting</h4>
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
