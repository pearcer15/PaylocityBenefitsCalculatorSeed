import Dependent from '../Dependent';
import AddDependentModal from './AddDependentModal';
import Modal from 'react-modal';
import React from 'react';

class AddEmployeeModal extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            dependents: this.props.data?.dependents?.length > 0 ? this.props.data.dependents : [],
            addOpen: false
        }
    }

    onModalClose = (event) => {
        this.props.onCloseModal(event);
    }

    openAddModal = () => {
        this.setState({
         addOpen: true
        })
     }
 
     handleCloseAddModal = () => {
         this.setState({
             addOpen: false
         })
     } 

     render() {
    return (
        <div>
        <Modal
            isOpen={this.props.IsModalOpen}
            ariaHideApp={false}
        >
            <h1>Add/Edit Employee</h1>
            <button type="button" className="btn-close" data-bs-dismiss="modal" aria-label="Close" onClick={this.onModalClose}></button>
            <div>
                {this.props.data.firstName}
            <table className="table caption-top">
                <caption>Dependents</caption>
                <thead className="table-dark">
                    <tr>
                        <th scope="col">Id</th>
                        <th scope="col">LastName</th>
                        <th scope="col">FirstName</th>
                        <th scope="col">DOB</th>
                        <th scope="col">Relationship</th>
                        <th scope="col">Actions</th>
                    </tr>
                </thead>
                <tbody>
                {this.state.dependents.map(({id, firstName, lastName, dateOfBirth, relationship}) => (
                    <Dependent
                    key={id}
                    id={id}
                    firstName={firstName}
                    lastName={lastName}
                    dateOfBirth={dateOfBirth}
                    relationship={relationship}
                    />
                    ))}
                </tbody>
            </table>
            <AddDependentModal
                data={[]}
                IsModalOpen={this.state.addOpen}
                onCloseModal={this.handleCloseAddModal}
            />
            <button type="button" className="btn btn-primary" onClick={this.openAddModal}>Add Dependent</button>
            </div>
            <div className="modal-footer">
                <button type="button" className="btn btn-secondary" data-bs-dismiss="modal" onClick={this.onModalClose}>Close</button>
                <button type="button" className="btn btn-primary">Save changes</button>
            </div>
        </Modal>
        </div>
    );
    }
};

export default AddEmployeeModal;