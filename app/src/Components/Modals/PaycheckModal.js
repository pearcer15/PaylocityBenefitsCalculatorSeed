import React from 'react';
import Modal from 'react-modal';
import { currencyFormat } from '../../Utilities/Constants';

class PaycheckModal extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            grossWages: this.props.data?.grossWages || 0,
            baseBenefits: this.props.data?.baseBenefits || 0,
            dependentBenefits: this.props.data?.dependentBenefits || 0,
            highWagePremium: this.props.data?.highWagePremium || 0,
            seniorPremium: this.props.data?.seniorPremium || 0,
            netWages: this.props.data?.netWages || 0,
        }
    }

    handleAfterOpen = () => {
        this.setState({
            grossWages: this.props.data?.grossWages || 0,
            baseBenefits: this.props.data?.baseBenefits || 0,
            dependentBenefits: this.props.data?.dependentBenefits || 0,
            highWagePremium: this.props.data?.highWagePremium || 0,
            seniorPremium: this.props.data?.seniorPremium || 0,
            netWages: this.props.data?.netWages || 0,
        })
    }

    onModalClose = () => {
        this.props.onCloseModal(false);
    }

    render() {
        return (
        <div>
        <Modal
            isOpen={this.props.IsModalOpen}
            ariaHideApp={false}
            onAfterOpen={this.handleAfterOpen}
        >
            <h1>Paystub</h1>
            <button type="button" className="btn-close" data-bs-dismiss="modal" aria-label="Close" onClick={this.onModalClose}></button>
            <div>Gross Wage: {currencyFormat(this.state.grossWages)}</div>
            <div>Base Benefits: ({currencyFormat(this.state.baseBenefits)})</div>
            <div>Dependent Benefits: ({currencyFormat(this.state.dependentBenefits)})</div>
            <div>High Wage Premium: ({currencyFormat(this.state.highWagePremium)})</div>
            <div>Senior Premium: ({currencyFormat(this.state.seniorPremium)})</div>
            <div>Net Wages: {currencyFormat(this.state.netWages)}</div>

        </Modal>
        </div>
    );}
};

export default PaycheckModal;