import Dependent from '../Dependent';
import AddDependentModal from './AddDependentModal';
import Modal from 'react-modal';

function EditEmployeeModal (props) {
    const dependents = props.data?.dependents?.length > 0 ? props.data.dependents : [];
    const addDependentModalId = "add-dependent-modal";

    function onModalClose(event) {
        props.onCloseModal(event);
    }

    return (
        <div>
        <Modal
            isOpen={props.IsModalOpen}
            ariaHideApp={false}
        >
            <h1>Add/Edit Employee</h1>
            <button type="button" className="btn-close" data-bs-dismiss="modal" aria-label="Close" onClick={onModalClose}></button>
            <div>
                {props.data.firstName}
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
                {dependents.map(({id, firstName, lastName, dateOfBirth, relationship}) => (
                    <Dependent
                    key={id}
                    id={id}
                    firstName={firstName}
                    lastName={lastName}
                    dateOfBirth={dateOfBirth}
                    relationship={relationship}
                    editModalId={addDependentModalId}
                    />
                    ))}
                </tbody>
            </table>
            <button type="button" className="btn btn-primary" data-bs-toggle="modal" data-bs-target={`#${addDependentModalId}`}>Add Dependent</button>
            <AddDependentModal
            id={addDependentModalId}
            />
            </div>
            <div className="modal-footer">
                <button type="button" className="btn btn-secondary" data-bs-dismiss="modal" onClick={onModalClose}>Close</button>
                <button type="button" className="btn btn-primary">Save changes</button>
            </div>
        </Modal>
        </div>
    );
};

export default EditEmployeeModal;