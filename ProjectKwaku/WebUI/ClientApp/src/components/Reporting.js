import React, { Component } from 'react';

export class Reporting extends Component {
    static displayName = Reporting.name;

  constructor(props) {
      super(props);

      this.state = {
          checkSheetTypes: [],
          loading: true
      };
    }

    componentDidMount() {
        this.getCheckSheetTypes();
    }

    async getCheckSheetTypes() {
        const response = await fetch('api/checksheets/types');
        const data = await response.json();
        this.setState({ checkSheetTypes: data, loading: false });
    }

    renderSelect(checkSheetTypes) {
        return (
            <select>
                {
                    checkSheetTypes.map(checkSheetType =>
                        <option key={checkSheetType.checkSheetTypeId}>
                            {checkSheetType.name}
                        </option>
                    )
                }
            </select>
        );
    }

    render() {

        var content = (this.state.loading) ? "<h1>Loading...</h1>" : this.renderSelect(this.state.checkSheetTypes);

        return (
          <>
              <div id="sub-header" className="d-flex flex-row align-items-center justify-content-between py-0 px-4 border-bottom bg-white">
                  <div>
                      <h4 id="sub-header-title" className="m-0 p-0">Reporting</h4>
                  </div>
              </div>

              {content}
          </>
        );
    }
}
