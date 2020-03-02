import React, { Component } from 'react';

export class Reporting extends Component {
    static displayName = Reporting.name;

  constructor(props) {
    super(props);
  }

  render() {
      return (

          <>

              <div id="sub-header" className="d-flex flex-row align-items-center justify-content-between py-0 px-4 border-bottom bg-white">
                  <div>
                      <h4 id="sub-header-title" className="m-0 p-0">Reporting</h4>
                  </div>
              </div>
        </>
    );
  }
}
